(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'infoTrigger') {

            const modalBody = document.querySelector('#modalBodyInfo').children;
            const infoDiv = e.target.parentElement.parentElement;

            const id = infoDiv.querySelector('#id').textContent;
            const location = infoDiv.querySelector('.locationText span').textContent;
            const camera = infoDiv.querySelector('.cameraText span').textContent;
            const likes = infoDiv.querySelector('.likesText span').textContent;
            const dislikes = infoDiv.querySelector('.dislikesText span').textContent;
            const length = infoDiv.querySelector('.lengthText span').textContent;

            modalBody[0].querySelector('#locationName').textContent = location;
            modalBody[1].querySelector('#cameraName').textContent = camera;
            modalBody[2].querySelector('#lengthName').textContent = length;
            modalBody[3].querySelector('#likesName').textContent = likes;
            modalBody[4].querySelector('#dislikesName').textContent = dislikes;
            modalBody[6].textContent = id;
            $('#VideoInfoModal').modal('show')
        }
    }
})(jQuery);