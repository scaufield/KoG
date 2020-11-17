(function ($) {
  "use strict";

  var nav_offset_top = $(".header_top").height();
  /*-------------------------------------------------------------------------------
	  Navbar 
	-------------------------------------------------------------------------------*/

  //* Navbar Fixed
  function navbarFixed() {
    if ($("#header").length) {
      $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll >= nav_offset_top) {
          $("#header").addClass("navbar_fixed");
        } else {
          $("#header").removeClass("navbar_fixed");
        }
      });
    }
  }
  navbarFixed();

  /*--------------- mobile dropdown js--------*/
  function active_dropdown2() {
    $(".menu > li .mobile_dropdown_icon").on("click", function () {
      $(this).parent().find("> ul").first().slideToggle(300);
      $(this).parent().siblings().find("> ul").hide(300);
      return false;
    });
  }
  active_dropdown2();

  /*----------------------------------------------------*/
  /*  Main Slider js
    /*----------------------------------------------------*/
  $(".main_slider").on("init", function (e, slick) {
    var $firstAnimatingElements = $("div.slider_item:first-child").find(
      "[data-animation]"
    );
    doAnimations($firstAnimatingElements);
  });
  $(".main_slider").on("beforeChange", function (
    e,
    slick,
    currentSlide,
    nextSlide
  ) {
    var $animatingElements = $(
      'div.slider_item[data-slick-index="' + nextSlide + '"]'
    ).find("[data-animation]");
    doAnimations($animatingElements);
  });
  var slideCount = null;

  $(".main_slider").on("init", function (event, slick) {
    slideCount = slick.slideCount;
    setSlideCount();
    setCurrentSlideNumber(slick.currentSlide);
  });
  $(".main_slider").on("beforeChange", function (
    event,
    slick,
    currentSlide,
    nextSlide
  ) {
    setCurrentSlideNumber(nextSlide);
  });

  function setSlideCount() {
    var $el = $(".slide-count-wrap").find(".total");
    if (slideCount < 10) {
      $el.text("0" + slideCount);
    } else {
      $el.text(slideCount);
    }
  }

  function setCurrentSlideNumber(currentSlide) {
    var $el = $(".slide-count-wrap").find(".current");
    $el.text(currentSlide + 1);
  }

  $(".main_slider").slick({
    autoplay: true,
    autoplaySpeed: 5000,
    dots: false,
    fade: true,
    prevArrow: ".left_arrow",
    nextArrow: ".right_arrow",
  });

  function doAnimations(elements) {
    var animationEndEvents =
      "webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend";
    elements.each(function () {
      var $this = $(this);
      var $animationDelay = $this.data("delay");
      var $animationType = "animated " + $this.data("animation");
      $this.css({
        "animation-delay": $animationDelay,
        "-webkit-animation-delay": $animationDelay,
      });
      $this.addClass($animationType).one(animationEndEvents, function () {
        $this.removeClass($animationType);
      });
    });
  }

  /*----------------------------------------------------*/
  /*  Main Slider js
  /*----------------------------------------------------*/

  if ($(".portfolio_slider").length) {
    $(".portfolio_slider").slick({
      autoplay: true,
      slidesToShow: 4,
      slidesToScroll: 1,
      autoplaySpeed: 3000,
      speed: 1000,
      dots: false,
      arrows: true,
      prevArrow: ".prev",
      nextArrow: ".next",
      responsive: [
        {
          breakpoint: 992,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 1,
          },
        },
        {
          breakpoint: 768,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 1,
          },
        },
        {
          breakpoint: 480,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1,
          },
        },
      ],
    });
  }

  if (
    $(".testimonial_area,.testimonial_area_two,.testimonial_area_four").length
  ) {
    $(".testimonial_slider").slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      arrows: false,
      swipe: false,
      asNavFor: ".testimonial_thumbnil",
    });
    $(".testimonial_thumbnil").slick({
      slidesToShow: 4,
      slidesToScroll: 1,
      asNavFor: ".testimonial_slider",
      centerMode: true,
      swipe: false,
      arrows: false,
      focusOnSelect: true,
      responsive: [
        {
          breakpoint: 576,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 1,
          },
        },
      ],
    });
  }

  if ($(".post_slider").length) {
    $(".post_slider").slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      arrows: true,
      prevArrow: ".left",
      nextArrow: ".right",
    });
  }

  function parallax() {
    var windowWidth = $(window).width();
    if ($(".parallax_effect").length) {
      if (windowWidth > 768) {
        $(".parallax_effect").parallaxie({
          speed: 0.5,
        });
      }
    }
  }
  parallax();

  // Counter up
  $(".counter").counterUp({
    delay: 10,
    time: 1000,
  });

  // Progress circle
  $(".circle1").each(function () {
    $(this).waypoint(
      function () {
        $(".circle1").circleProgress({
          value: 0.75,
          size: 150,
          emptyFill: "#fff",
          thickness: 4,
          startAngle: 4.7,
          animation: { duration: 3000 },
          fill: {
            gradient: ["#8781bd"],
          },
        });
      },
      {
        triggerOnce: true,
        offset: "bottom-in-view",
      }
    );
  });

  $(".circle2").each(function () {
    $(this).waypoint(
      function () {
        $(".circle2").circleProgress({
          value: 0.5,
          size: 150,
          emptyFill: "#fff",
          thickness: 4,
          startAngle: 4.7,
          animation: { duration: 3000 },
          fill: {
            gradient: ["#8781bd"],
          },
        });
      },
      {
        triggerOnce: true,
        offset: "bottom-in-view",
      }
    );
  });

  $(".circle3").each(function () {
    $(this).waypoint(
      function () {
        $(".circle3").circleProgress({
          value: 0.62,
          size: 150,
          emptyFill: "#fff",
          thickness: 4,
          startAngle: 4.7,
          animation: { duration: 3000 },
          fill: {
            gradient: ["#8781bd"],
          },
        });
      },
      {
        triggerOnce: true,
        offset: "bottom-in-view",
      }
    );
  });

  $(".circle4").each(function () {
    $(this).waypoint(
      function () {
        $(".circle4").circleProgress({
          value: 0.92,
          size: 150,
          emptyFill: "#fff",
          thickness: 4,
          startAngle: 4.7,
          animation: { duration: 3000 },
          fill: {
            gradient: ["#8781bd"],
          },
        });
      },
      {
        triggerOnce: true,
        offset: "bottom-in-view",
      }
    );
  });
  /*-------------------------------------------------------------------------------
	  Portfolio isotope js
	-------------------------------------------------------------------------------*/
  function portfolioMasonry() {
    var portfolio = $("#work-portfolio");
    if (portfolio.length) {
      portfolio.imagesLoaded(function () {
        // images have loaded
        // Activate isotope in container
        portfolio.isotope({
          // itemSelector: ".portfolio_item",
          layoutMode: "masonry",
          filter: "*",
          animationOptions: {
            duration: 1000,
          },
          transitionDuration: "0.5s",
          masonry: {},
        });

        // Add isotope click function
        $("#portfolio_filter div").on("click", function () {
          $("#portfolio_filter div").removeClass("active");
          $(this).addClass("active");

          var selector = $(this).attr("data-filter");
          portfolio.isotope({
            filter: selector,
            animationOptions: {
              animationDuration: 750,
              easing: "linear",
              queue: false,
            },
          });
          return false;
        });
      });
    }
  }
  portfolioMasonry();

  /*-------------------------------------------------------------------------------
	  popup js
	-------------------------------------------------------------------------------*/
  function popupGallery() {
    if ($(".popup").length) {
      $(".popup").each(function () {
        $(".popup").magnificPopup({
          type: "image",
          tLoading: "Loading image #%curr%...",
          removalDelay: 300,
          mainClass: "mfp-with-zoom mfp-img-mobile",
          gallery: {
            enabled: true,
            navigateByImgClick: false,
            preload: [0, 1],
          },
        });
      });
    }
    if ($(".popup-youtube").length) {
      $(".popup-youtube").magnificPopup({
        disableOn: 700,
        type: "iframe",
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false,
        mainClass: "mfp-with-zoom mfp-img-mobile",
      });
    }
  }
  popupGallery();

  /*-------------------------------------------------------------------------------
	  WOW js
	-------------------------------------------------------------------------------*/
  function wowAnimation() {
    new WOW({
      offset: 100,
      mobile: true,
    }).init();
  }
  wowAnimation();

  function loader() {
    $(window).on("load", function () {
      $("#ctn-preloader").addClass("loaded");
      // Una vez haya terminado el preloader aparezca el scroll

      if ($("#ctn-preloader").hasClass("loaded")) {
        // Es para que una vez que se haya ido el preloader se elimine toda la seccion preloader
        $("#preloader")
          .delay(900)
          .queue(function () {
            $(this).remove();
          });
      }
    });
  }
  loader();
})(jQuery);
