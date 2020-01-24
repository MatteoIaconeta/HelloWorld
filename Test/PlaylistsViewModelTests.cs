using HelloWorld.ViewModels;
using HelloWorld.Views;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture()]
    public class PlaylistsViewModelTests
    {
        private PlaylistsViewModel viewModel;
        private Mock<IPageService> pageService;

        [SetUp]
        public void Setup()
        {
            pageService = new Mock<IPageService>();
            viewModel = new PlaylistsViewModel(pageService.Object);
        }
        [Test]
        public void AddPlaylist_WhenCalled_TheNewPlaylistShouldBeInTheList()
        {
            viewModel.AddPlaylistCommand.Execute(null);
            Assert.AreEqual(1, viewModel.Playlists.Count);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_TheSelectedItemShouldBeDeselected()
        {
            var playlist = new PlaylistViewModel();
            viewModel.Playlists.Add(playlist);
            viewModel.SelectPlaylistCommand.Execute(playlist);
            Assert.IsNull(viewModel.SelectedPlaylist);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_IsFavoritePropertyOfPlaylistIsToggled()
        {
            var playlist = new PlaylistViewModel();
            viewModel.Playlists.Add(playlist);
            viewModel.SelectPlaylistCommand.Execute(playlist);
            Assert.IsTrue(playlist.IsFavorite);
        }

        [Test]
        public void SelectPlaylist_WhenCalled_ShouldNavigateTheUserToPlaylistDetailPage()
        {
            var playlist = new PlaylistViewModel();
            viewModel.Playlists.Add(playlist);
            viewModel.SelectPlaylistCommand.Execute(playlist);
            pageService.Verify(p => p.PushAsync(It.IsAny<PlaylistDetailPage>()));
        }
    }
}