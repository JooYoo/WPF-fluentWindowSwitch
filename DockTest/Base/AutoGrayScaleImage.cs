// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoGrayScaleImage.cs" company="artiso solutions GmbH">
//   Copyright (c) artiso solutions GmbH
// </copyright>
// <author>
//   Maximilian Koepf
//</author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DockTest.Base
{
    /// <summary>Image that supports gray scaling on disabling.</summary>
    /// <seealso cref="System.Windows.Controls.Image"/>
    public class AutoGrayScaleImage : Image
    {
        #region Constructors and Destructors

        /// <summary>Initializes static members of the <see cref="AutoGrayScaleImage"/> class.</summary>
        static AutoGrayScaleImage()
        {
            // Override the metadata of the IsEnabled property.
            IsEnabledProperty.OverrideMetadata(typeof(AutoGrayScaleImage), new FrameworkPropertyMetadata(true, OnIsEnabledPropertyChanged));
            SourceProperty.OverrideMetadata(typeof(AutoGrayScaleImage), new FrameworkPropertyMetadata(null, OnImageSourcePropertyChanged));
        }

        #endregion

        #region Methods

        private static void ApplyGrayScaleEffect(Image autoGrayScaleImage, bool isEnabled)
        {
            try
            {
                if (!isEnabled)
                {
                    if (autoGrayScaleImage.Source is FormatConvertedBitmap)
                    {
                        // Image is already grayscaled.
                        return;
                    }

                    var imageSource = autoGrayScaleImage.Source as BitmapSource ?? new BitmapImage(new Uri(autoGrayScaleImage.Source.ToString()));

                    // Convert it to Gray
                    autoGrayScaleImage.Source = new FormatConvertedBitmap(imageSource, PixelFormats.Gray32Float, null, 0);

                    // Create Opacity Mask for greyscale image as FormatConvertedBitmap does not keep transparency info
                    autoGrayScaleImage.OpacityMask = new ImageBrush(imageSource);
                }
                else
                {
                    var formatConvertedBitmapSource = autoGrayScaleImage.Source as FormatConvertedBitmap;

                    if (formatConvertedBitmapSource != null)
                    {
                        autoGrayScaleImage.Source = formatConvertedBitmapSource.Source;
                    }
                    else if (autoGrayScaleImage.Source is BitmapSource)
                    {
                        // Image is already colored.
                        return;
                    }

                    autoGrayScaleImage.OpacityMask = null;
                }
            }
            catch (Exception)
            {
                // show at least the default source if something happens
            }
        }

        private static AutoGrayScaleImage GetAutoGrayScaleImage(DependencyObject source)
        {
            var image = source as AutoGrayScaleImage;

            if (image == null)
            {
                return null;
            }

            return image.Source == null ? null : image;
        }

        private static void OnImageSourcePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var autoGrayScaleImage = GetAutoGrayScaleImage(source);

            if (autoGrayScaleImage != null)
            {
                ApplyGrayScaleEffect(autoGrayScaleImage, autoGrayScaleImage.IsEnabled);
            }
        }

        /// <summary>Called when [auto grey scale image is enabled property changed].</summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnIsEnabledPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            var autoGrayScaleImage = GetAutoGrayScaleImage(source);

            var isEnable = Convert.ToBoolean(args.NewValue);

            if (autoGrayScaleImage == null)
            {
                return;
            }

            ApplyGrayScaleEffect(autoGrayScaleImage, isEnable);
        }

        #endregion
    }
}