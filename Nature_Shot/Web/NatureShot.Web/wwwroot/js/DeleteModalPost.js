(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'deleteTrigger') {

            const id = e.target.parentElement.parentElement.querySelector('#id').textContent;
            const input = document.querySelector('#deleteModal').querySelector('#deleteFooter').querySelector('form #postId').setAttribute('value', id);
            $('#deleteModal').modal('show')
        }
    }

})(jQuery);