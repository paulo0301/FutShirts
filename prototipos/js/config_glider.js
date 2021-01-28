window.addEventListener('load', function(){
    new Glider(document.querySelector('#glider01'), {
        slidesToShow: 3,
        slidesToScroll: 3,
        draggable: true,
        scrollLock: true,
        arrows: false,
        arrows: {
            prev: '#glider-prev01',
            next: '#glider-next01'
        },
        responsive: [
            {
                breakpoint: 675,
                settings: {
                    slidesToShow: 7,
                    slidesToScroll: 4,
                    itemWidth: 150,
                }
            },{
                breakpoint: 1024,
                settings: {
                    slidesToShow: 10,
                    slidesToScroll: 5,
                    itemWidth: 150,
                }
            }
        ]
    });
})