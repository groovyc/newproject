﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


using Windows.Media.Capture;  //added all
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Input;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Windows.UI.Xaml.Media.Imaging;
// To add offline sync support, add the NuGet package Microsoft.WindowsAzure.MobileServices.SQLiteStore
// to your project. Then, uncomment the lines marked // offline sync
// For more information, see: http://aka.ms/addofflinesync
//using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
//using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync

namespace fourchordproject
{
    sealed partial class MainPage: Page
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        //private IMobileServiceSyncTable<TodoItem> todoTable = App.MobileService.GetSyncTable<TodoItem>(); // offline sync

        public MainPage()
        {
            this.InitializeComponent();
        }
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

        //commented out
        private async Task InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);
            todoItem.Id = string.Format("partition,{0}", Guid.NewGuid()); //added
            //await SyncAsync(); // offline sync
        }

        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
                this.ButtonSave.IsEnabled = true;
            }
        }

        private async Task UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
            ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

            //await SyncAsync(); // offline sync
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            ButtonRefresh.IsEnabled = false;

            //await SyncAsync(); // offline sync
            await RefreshTodoItems();

            ButtonRefresh.IsEnabled = true;
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var todoItem = new TodoItem { Text = TextInput.Text };
            await InsertTodoItem(todoItem);
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            await UpdateCheckedTodoItem(item);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //await InitLocalStoreAsync(); // offline sync
            await RefreshTodoItems();
        }

        #region Offline sync

        //private async Task InitLocalStoreAsync()
        //{
        //    if (!App.MobileService.SyncContext.IsInitialized)
        //    {
        //        var store = new MobileServiceSQLiteStore("localstore.db");
        //        store.DefineTable<TodoItem>();
        //        await App.MobileService.SyncContext.InitializeAsync(store);
        //    }
        //
        //    await SyncAsync();
        //}

        //private async Task SyncAsync()
        //{
        //    await App.MobileService.SyncContext.PushAsync();
        //    await todoTable.PullAsync("todoItems", todoTable.CreateQuery());
        //}

        #endregion 



       
    }
}
