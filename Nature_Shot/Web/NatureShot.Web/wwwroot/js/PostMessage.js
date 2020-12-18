(function ($) {
    "use strict";

    const container = document.querySelector('#sendButton').addEventListener('click', SendMessage);


    function SendMessage() {

        const input = document.querySelector('#messageInput').value;
        if (input != '' && input.length <= 300) {
            const antiForgeryToken = document.querySelector('#messageForm').querySelector('input[name=__RequestVerificationToken]').getAttribute('value');
            const params = new URLSearchParams(window.location.search);
            const receiver = params.get('username');
            $.ajax({
                type: "Post",
                url: "/api/ChatAjax",
                data: JSON.stringify({ message: input, receiver: receiver }),
                headers: {
                    'X-CSRF-TOKEN': antiForgeryToken
                },
                success: function (data) {
                    document.querySelector('#messageInput').value = '';
                    document.querySelector('#messagesList').innerHTML += "<li class=\"text-right offset-1 col-11 mb-4\"><p>" + data.username + "<br><span class=\"d-inline-block p-2 pl-3 pr-3 rounded border border-primary bg-primary text-white\">" + data.message + "</span><br><small>" + data.timePosted + "</small></p></li>";
                },
                contentType: 'application/json',
            });
        }
        else {
            document.querySelector('#messageInput').value = '';
            document.querySelector('#messageInput').setAttribute('placeholder', 'Message max length is 300');
        }
    }


})(jQuery);