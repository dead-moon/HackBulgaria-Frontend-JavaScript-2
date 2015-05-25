

    jQuery.noConflict();

    /* tooltip for socials init */

    function tooltipInit() {

        jQuery("[data-toggle='tooltip']").tooltip();
    }


    function linearFlexsliderInit() {
        jQuery('.flexslider.flexLinear').flexslider({
            animation: 'slide',
            animationLoop: false,
            slideshow: false,
            controlNav: false,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
            directionNav: true,
            start: function(){
                overlayContent('reload');
            }
        });
    }

    function fadeFlexsliderInit() {
        jQuery('.flexslider.fadeFlex').flexslider({
            animation: 'fade',
            animationLoop: false,
            slideshow: false,
            controlNav: false,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
            directionNav: true,
            start: function(){
                overlayContent('reload');
            }
        });
    }

    function fullFlexsliderInit() {
        jQuery('.flexslider.flexFull').flexslider({
            animation: "slide",
            slideshowSpeed: 7000,           //Integer: Set the speed of the slideshow cycling, in milliseconds
            animationSpeed: 600,
            pauseOnAction: true,
            controlNav: true,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
            directionNav: true
        });
    }

    function carouselFlexsliderInit() {
        jQuery('.flexslider.flexCarousel').flexslider({
            animation: "slide",
            animationLoop: true,
            itemWidth: 140,                   //{NEW} Integer: Box-model width of individual carousel items, including horizontal borders and padding.
            minItems: 2,                    //{NEW} Integer: Minimum number of carousel items that should be visible. Items will resize fluidly when below this.
            maxItems: 6,                    //{NEW} Integer: Maxmimum number of carousel items that should be visible. Items will resize fluidly when above this limit.
            move: 0,                        //{NEW} Integer: Number of carousel items that should move on animation. If 0, slider will move all visible items.
            controlNav: false,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
            directionNav: true
          });
    }



    function contentFlexsliderInit() {
        jQuery('.flexslider.flexContent').flexslider({
            animation: "slide",
            slideshowSpeed: 7000,           //Integer: Set the speed of the slideshow cycling, in milliseconds
            animationSpeed: 600,
            pauseOnAction: true,
            controlNav: false,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
            directionNav: true
        });
    }


    /* content on hover */
    function overlayContent(i) {
        if (i == 'init') {
            jQuery('.contentoverlay').contenthover({
                overlay_opacity: 0.6,
                effect: 'fade',                 // [fade, slide, show] The effect to use
                fade_speed: 400,                // Effect ducation for the 'fade' effect only
                slide_speed: 400,               // Effect ducation for the 'slide' effect only
                slide_direction: 'bottom'      // [top, bottom, right, left] From which direction should the overlay apear, for the slide effect only
            });
        }
        if (i == 'reload') {
            /* responsive overlay fix */
            jQuery('.ch_element').remove();
            jQuery('.contentoverlay').show();
            overlayContent('init');
        }
    }

    /* link smooth scroll to top */
    function scrollToTop(i) {
        if (i == 'show') {
            if (jQuery(this).scrollTop() != 0) {
                jQuery('#toTop').fadeIn();
            } else {
                jQuery('#toTop').fadeOut();
            }
        }
        if (i == 'click') {
            jQuery('#toTop').click(function () {
                jQuery('body,html').animate({scrollTop: 0}, 600);
                return false;
            });
        }
    }

    jQuery(document).ready(function () {
        overlayContent('init');
        scrollToTop('click');
        tooltipInit();
    });

    jQuery(window).resize(function () {
        overlayContent('reload');
    });

    jQuery(window).scroll(function () {
        scrollToTop('show');
    });

    jQuery(window).load(function () {
        fullFlexsliderInit();
        linearFlexsliderInit();
        fadeFlexsliderInit();
        contentFlexsliderInit();
    });

