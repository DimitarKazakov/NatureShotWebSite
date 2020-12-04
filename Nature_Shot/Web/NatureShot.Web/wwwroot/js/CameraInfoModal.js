(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'cameraName') {

            const iframe = document.querySelector('#modalBodyCamera').querySelector('iframe');
            const location = e.target.textContent;

            iframe.setAttribute('src', 'https://en.wikipedia.org/wiki/' + location);
            $('#cameraModal').modal('show')
        }
    }
})(jQuery);