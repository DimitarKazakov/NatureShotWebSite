(function ($) {
    window.addEventListener('load', ScrollToBottom);

    function ScrollToBottom() {
        const element = document.querySelector("#message-holder");
        element.scrollIntoView({ behavior: 'smooth', block: 'end' });
    }

})(jQuery);