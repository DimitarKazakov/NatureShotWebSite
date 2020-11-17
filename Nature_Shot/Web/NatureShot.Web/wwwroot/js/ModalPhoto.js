(function ($) {
    "use strict"; // Start of use strict

    //Modal photo change

    const modalPhoto = document.querySelector('#modalPhoto');
    const modalInfo = document.querySelector('#modalInfo').children;
    const photoSection = document.querySelector('#photosClick').addEventListener('click', showModal);
    document.querySelector('#imagesDiv').addEventListener('click', showModal);

    function showModal(e) {

        const target = e.target;
        const targetName = target.tagName;

        console.log("works");
        if (targetName === 'IMG') {

            let source = target.getAttribute('src');
            modalPhoto.removeAttribute('src');
            modalPhoto.setAttribute('src', source);

            const infoDiv = target.parentElement.nextElementSibling.children[0];

            const location = infoDiv.querySelector('.locationText span').textContent;
            const camera = infoDiv.querySelector('.cameraText span').textContent;
            const likes = infoDiv.querySelector('.likesText span').textContent;
            const dislikes = infoDiv.querySelector('.dislikesText span').textContent;

            modalInfo[0].querySelector('span').textContent = location;
            modalInfo[1].querySelector('span').textContent = camera;
            modalInfo[2].querySelector('span').textContent = likes;
            modalInfo[3].querySelector('span').textContent = dislikes;
        }
    }



})(jQuery); // End of use strict

