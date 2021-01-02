window.addEventListener('load', function(){
    new Glider(document.querySelector('.glider'), {
        slidesToShow: 10,
        slidesToScroll: 5,
        itemWidth: 50,
        draggable: true,
        scrollLock: true,
        dots: '#dots',
        rewind: true,
        arrows: {
            prev: '.glider-prev',
            next: '.glider-next'
        },
        // responsive: [
        //     {
        //         breakpoint: 800,
        //         settings: {
        //             slidesToScroll: 'auto',
        //             itemWidth: 50,
        //             slidesToShow: 'auto',
        //             exactWidth: true
        //         }
        //     },
        //     {
        //         breakpoint: 700,
        //         settings: {
        //             slidesToScroll: 4,
        //             slidesToShow: 4,
        //             dots: false,
        //             arrows: false,
        //         }
        //     },
        //     {
        //         breakpoint: 600,
        //         settings: {
        //             slidesToScroll: 3,
        //             slidesToShow: 3
        //         }
        //     },
        //     {
        //         breakpoint: 500,
        //         settings: {
        //             slidesToScroll: 2,
        //             slidesToShow: 2,
        //             dots: false,
        //             arrows: false,
        //             scrollLock: true
        //         }
        //     }
        // ]
    });
    })