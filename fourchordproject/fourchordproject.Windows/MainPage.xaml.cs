using Windows.UI.Xaml.Controls;

namespace fourchordproject
{
    public sealed partial class MainPage : Page
    {

        ///added all this below
        ///
        // Use a StorageFile to hold the captured image for upload.
//        StorageFile media = null;
//        MediaCapture cameraCapture;
//        bool IsCaptureInProgress;

//        private async Task CaptureImage()
//        {
//            // Capture a new photo or video from the device.
//            cameraCapture = new MediaCapture();
//            cameraCapture.Failed += cameraCapture_Failed;

//            // Initialize the camera for capture.
//            await cameraCapture.InitializeAsync();

//#if WINDOWS_PHONE_APP
//    cameraCapture.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
//    cameraCapture.SetRecordRotation(VideoRotation.Clockwise90Degrees);
//#endif

//            captureGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
//            previewElement.Visibility = Windows.UI.Xaml.Visibility.Visible;
//            previewElement.Source = cameraCapture;
//            await cameraCapture.StartPreviewAsync();
//        }

//        private async void previewElement_Tapped(object sender, TappedRoutedEventArgs e)
//        {
//            // Block multiple taps.
//            if (!IsCaptureInProgress)
//            {
//                IsCaptureInProgress = true;

//                // Create the temporary storage file.
//                media = await ApplicationData.Current.LocalFolder
//                    .CreateFileAsync("capture_file.jpg", CreationCollisionOption.ReplaceExisting);

//                // Take the picture and store it locally as a JPEG.
//                await cameraCapture.CapturePhotoToStorageFileAsync(
//                    ImageEncodingProperties.CreateJpeg(), media);

//                captureButtons.Visibility = Visibility.Visible;

//                // Use the stored image as the preview source.
//                BitmapImage tempBitmap = new BitmapImage(new Uri(media.Path));
//                imagePreview.Source = tempBitmap;
//                imagePreview.Visibility = Visibility.Visible;
//                previewElement.Visibility = Visibility.Collapsed;
//                IsCaptureInProgress = false;
//            }
//        }

//        private async void cameraCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
//        {
//            // It's safest to return this back onto the UI thread to show the message dialog.
//            MessageDialog dialog = new MessageDialog(errorEventArgs.Message);
//            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
//                async () => { await dialog.ShowAsync(); });
//        }

//        private async void ButtonCapture_Click(object sender, RoutedEventArgs e)
//        {
//            // Prevent multiple initializations.
//            ButtonCapture.IsEnabled = false;

//            await CaptureImage();
//        }

//        private async void ButtonRetake_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
//        {
//            // Reset the capture and then start again.
//            await ResetCaptureAsync();
//            await CaptureImage();
//        }

//        private async void ButtonCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
//        {
//            await ResetCaptureAsync();
//        }

//        private async Task ResetCaptureAsync()
//        {
//            captureGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
//            imagePreview.Visibility = Visibility.Collapsed;
//            captureButtons.Visibility = Visibility.Collapsed;
//            previewElement.Source = null;
//            ButtonCapture.IsEnabled = true;

//            // Make sure we stop the preview and release resources.
//            await cameraCapture.StopPreviewAsync();
//            cameraCapture.Dispose();
//            media = null;
//        }


        //private async Task InsertTodoItem(TodoItem todoItem)
        //{
        //    string errorString = string.Empty;

        //    if (media != null)
        //    {
        //        // Set blob properties of TodoItem.
        //        todoItem.ContainerName = "todoitemimages";

        //        // Use a unigue GUID to avoid collisions.
        //        todoItem.ResourceName = Guid.NewGuid().ToString();
        //    }

        //    // Send the item to be inserted. When blob properties are set this
        //    // generates an SAS in the response.
        //    await todoTable.InsertAsync(todoItem);

        //    // If we have a returned SAS, then upload the blob.
        //    if (!string.IsNullOrEmpty(todoItem.SasQueryString))
        //    {
        //        // Get the URI generated that contains the SAS 
        //        // and extract the storage credentials.
        //        StorageCredentials cred = new StorageCredentials(todoItem.SasQueryString);
        //        var imageUri = new Uri(todoItem.ImageUri);

        //        // Instantiate a Blob store container based on the info in the returned item.
        //        CloudBlobContainer container = new CloudBlobContainer(
        //            new Uri(string.Format("https://{0}/{1}",
        //                imageUri.Host, todoItem.ContainerName)), cred);

        //        // Get the new image as a stream.
        //        using (var inputStream = await media.OpenReadAsync())
        //        {
        //            // Upload the new image as a BLOB from the stream.
        //            CloudBlockBlob blobFromSASCredential =
        //                container.GetBlockBlobReference(todoItem.ResourceName);
        //            await blobFromSASCredential.UploadFromStreamAsync(inputStream);
        //        }

        //        // When you request an SAS at the container-level instead of the blob-level,
        //        // you are able to upload multiple streams using the same container credentials.

        //        await ResetCaptureAsync();
        //    }

        //    // Add the new item to the collection.
        //    items.Add(todoItem);
        //}













    }
}
