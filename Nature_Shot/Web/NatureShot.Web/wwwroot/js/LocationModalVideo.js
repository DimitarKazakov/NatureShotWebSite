(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'locationName') {

            const iframe = document.querySelector('#modalBodyLocation').querySelector('iframe');
            const location = e.target.textContent;

            iframe.setAttribute('src', 'https://maps.google.com/maps?q=' + location + '&t=&z=13&ie=UTF8&iwloc=&output=embed');
            $('#locationModal').modal('show')
        }
    }
})(jQuery);