(function ($) {
    setInterval(CheckForMessage, 8000);
    function CheckForMessage() {
        let xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function (e) {

            if (this.readyState == 4 && this.status == 200) {
                const scrollHeight = window.scrollY;
                const scrollWidth = window.scrollX;

                let messages = JSON.parse(this.response);



                if (messages.length > 0) {

                    for (let i = 0; i < messages.length; i++) {
                        let message = messages[i];
                        document.querySelector('#messagesList').innerHTML += "<li class=\"text-left col-11 mb-4\"><p>" + message.username + "<br><span class=\"d-inline-block p-2 pl-3 pr-3 rounded border border-secondary bg-secondary text-white\">" + message.message + "</span><br><small>" + message.timePosted + "</small></p></li>";
                    }

                    window.scroll(scrollWidth, scrollHeight);

                }
            }
        }

        const paramsInUrl = new URLSearchParams(window.location.search);
        const usernameByParam = paramsInUrl.get('username');
        xhr.open("GET", "/api/ChatAjax?username=" + usernameByParam);
        xhr.send();
    }

})(jQuery);