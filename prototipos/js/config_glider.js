window.addEventListener('load', function(){
    new Glider(document.querySelector('#glider01'), {
        slidesToShow: 12,
        slidesToScroll: 6,
        draggable: true,
        scrollLock: true,
        arrows: {
            prev: '.glider-prev',
            next: '.glider-next'
        }
    });
    })