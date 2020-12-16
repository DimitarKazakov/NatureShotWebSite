(function ($) {
    const form = document.querySelector('#searchUserProfile');
    form.addEventListener('submit', addInput);
    form.preventDefault;
    function addInput(e) {
        const input = form.querySelector('input');
        form.setAttribute('action', 'Home/Profile/' + input.value);
        form.submit();
    }
})(jQuery);