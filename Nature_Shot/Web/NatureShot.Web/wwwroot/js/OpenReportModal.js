(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'reportTrigger') {

            const id = e.target.parentElement.parentElement.querySelector('#id').textContent;
            const input = document.querySelector('#reportModal').querySelector('#reportBody').querySelector('form #postId').setAttribute('value', id);
            $('#reportModal').modal('show')
        }
    }

})(jQuery);