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
    
    
});
$(document).ready(function(){
    $("#owl-carousel01").owlCarousel({
        loop: true,
        margin: 0,
        autoplay: true,
        autoplayTimeout: 5000,
        lazyLoad: true,
        nav: false,
        dots: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            900: {
                items: 3,
            },
            1300: {
                items: 4,
            }
        }
    })
    /////////////////////////////////////
    $("#owl-carousel02").owlCarousel({
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 10000,
        autoplayHoverPause: true,
        lazyLoad: true,
        nav: false,
        dots: false,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            900: {
                items: 3,
            },
            1300: {
                items: 4,
            }
        }
    })
});