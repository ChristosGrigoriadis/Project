
function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 6,
        center: { lat: 39.0742, lng: 21.8243 },
    });
    const geocoder = new google.maps.Geocoder();
    const infowindow = new google.maps.InfoWindow();
    document.getElementById("submit").addEventListener("click", () => {
        geocodeLatLng(geocoder, map, infowindow);
    });
}

function geocodeLatLng(geocoder, map, infowindow) {
    const input = document.getElementById("latlng").value;
    const latlngStr = input.split(",", 2);
    const latlng = {
        lat: parseFloat(latlngStr[0]),
        lng: parseFloat(latlngStr[1]),
    };
    geocoder.geocode({ location: latlng }, (results, status) => {
        if (status === "OK") {
            if (results[0]) {
                map.setZoom(10);
                const marker = new google.maps.Marker({
                    position: latlng,
                    map: map,
                    center: latlng
                });
                infowindow.setContent(results[0].formatted_address);
                infowindow.open(map, marker);
            } else {
                bootbox.alert("No results found");
            }
        } else {
            bootbox.alert("Geocoder failed due to: " + status);
        }
    });
}

