(function ($) {
    "use strict";

    document.querySelector('#photosClick').addEventListener('click', ShowVideoInfoModal);

    function ShowVideoInfoModal(e) {
        if (e.target.hasAttribute('id') && e.target.getAttribute('id') == 'reportTrigger') {

            const id = e.target.parentElement.parentElement.querySelector('#id').textContent;
            const input = document.querySelector('#reportModal').querySelector('#reportBody').querySelector('form #postId').setAttribute('value', id);
            $('#reportModal').modal('show')

            document.querySelector('#reportModal').querySelector('#sendReport').addEventListener('click', MakeReport);

            function MakeReport(e) {
                const body = e.target.parentElement.parentElement.querySelector('#reportBody');
                const subjectInput = body.querySelector('#subjectName');
                const contentInput = body.querySelector('#messageText');


                if (subjectInput.value.length >= 5 && subjectInput.value.length <= 100 && contentInput.value.length >= 10 && contentInput.value.length <= 500) {
                    const antiForgeryToken = body.querySelector('input[name=__RequestVerificationToken]').getAttribute('value');


                    $.ajax({
                        type: "Post",
                        url: "/api/ReactionPostsAjax",
                        data: JSON.stringify({ subject: subjectInput.value, postId: id, content: contentInput.value }),
                        headers: {
                            'X-CSRF-TOKEN': antiForgeryToken
                        },
                        success: function () {
                            $('#reportModal').modal('hide')
                        },
                        contentType: 'application/json',
                    });
                }
            }
        }

    }

})(jQuery);