/*----------------------------------------------------*/
/*  Google map js
/*----------------------------------------------------*/

if ($("#mapBox2").length) {
  var $lat = $("#mapBox2").data("lat");
  var $lon = $("#mapBox2").data("lon");
  var $zoom = $("#mapBox2").data("zoom");
  var $marker = $("#mapBox2").data("marker");
  var $info = $("#mapBox2").data("info");
  var $markerLat = $("#mapBox2").data("mlat");
  var $markerLon = $("#mapBox2").data("mlon");
  var map = new GMaps({
    el: "#mapBox2",
    lat: $lat,
    lng: $lon,
    scrollwheel: false,
    scaleControl: true,
    streetViewControl: false,
    panControl: true,
    disableDoubleClickZoom: true,
    mapTypeControl: false,
    zoom: $zoom,
    styles: [
      {
        featureType: "administrative",
        elementType: "labels.text.fill",
        stylers: [
          {
            color: "#444444",
          },
        ],
      },
      {
        featureType: "landscape",
        elementType: "all",
        stylers: [
          {
            color: "#f2f2f2",
          },
        ],
      },
      {
        featureType: "poi",
        elementType: "all",
        stylers: [
          {
            visibility: "off",
          },
        ],
      },
      {
        featureType: "road",
        elementType: "all",
        stylers: [
          {
            saturation: -100,
          },
          {
            lightness: 45,
          },
        ],
      },
      {
        featureType: "road.highway",
        elementType: "all",
        stylers: [
          {
            visibility: "simplified",
          },
        ],
      },
      {
        featureType: "road.arterial",
        elementType: "labels.icon",
        stylers: [
          {
            visibility: "off",
          },
        ],
      },
      {
        featureType: "transit",
        elementType: "all",
        stylers: [
          {
            visibility: "off",
          },
        ],
      },
      {
        featureType: "water",
        elementType: "all",
        stylers: [
          {
            color: "#46bcec",
          },
          {
            visibility: "on",
          },
        ],
      },
    ],
  });

  map.addMarker({
    lat: $markerLat,
    lng: $markerLon,
    icon: $marker,
    infoWindow: {
      content: $info,
    },
  });
}
