function initMap() {
}

 var app = new Vue({
        el: "#app",
        data: {

            map: "",
            sentimentResponse: [],
            userinput: "Trump",
            lat: "59.3293",
            lng: "18.0686",
            radius: 20,
            message: "",
            lengthOfResponse: "",
            seen: false,
            average: 0,
        },
        async created() {

        },
        mounted() {
            this.initMap();
        },
        methods: {
            initMap: function () {
                map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 9,
                    center: { lat: 59.3293, lng: 18.0686 },
                    //mapTypeId: 'hybrid',
                    styles: [
                        {
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#212121"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.icon",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#212121"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.country",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#9e9e9e"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.land_parcel",
                            "stylers": [
                                {
                                    "visibility": "off"
                                }
                            ]
                        },
                        {
                            "featureType": "administrative.locality",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#bdbdbd"
                                }
                            ]
                        },
                        {
                            "featureType": "poi",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#181818"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "poi.park",
                            "elementType": "labels.text.stroke",
                            "stylers": [
                                {
                                    "color": "#1b1b1b"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "geometry.fill",
                            "stylers": [
                                {
                                    "color": "#2c2c2c"
                                }
                            ]
                        },
                        {
                            "featureType": "road",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#8a8a8a"
                                }
                            ]
                        },
                        {
                            "featureType": "road.arterial",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#373737"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#3c3c3c"
                                }
                            ]
                        },
                        {
                            "featureType": "road.highway.controlled_access",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#4e4e4e"
                                }
                            ]
                        },
                        {
                            "featureType": "road.local",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#616161"
                                }
                            ]
                        },
                        {
                            "featureType": "transit",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#757575"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "geometry",
                            "stylers": [
                                {
                                    "color": "#000000"
                                }
                            ]
                        },
                        {
                            "featureType": "water",
                            "elementType": "labels.text.fill",
                            "stylers": [
                                {
                                    "color": "#3d3d3d"
                                }
                            ]
                        }
                    ]

                });

                this.marker = new google.maps.Marker({
                    position: { lat: 59.3293, lng: 18.0686 },
                    map: map,
                    draggable: true
                });
                google.maps.event.addListener(this.marker, 'mouseover', function () {
                    infowindow.open(map, this.marker);
                });

                google.maps.event.addListener(this.marker, 'mouseout', function () {
                    infowindow.close(map, this.marker);
                });
                google.maps.event.addListener(this.marker, 'dragend', function () {

                    app.lat = this.getPosition().lat();
                    app.lng = this.getPosition().lng();
                });
            },

            async showTweetSentiment() {
                let response = await fetch("/Tweet/TwitterResult/?input=" + this.userinput + "&lat=" + this.lat + "&lng=" + this.lng + "&radius=" + this.radius, {
                    method: "get"
                });

                    this.sentimentResponse = await response.json();

                this.lengthOfResponse = this.sentimentResponse.length;

                if (this.sentimentResponse.length === 0) {
                    this.message = "No results found!"
                   
                } else if (this.sentimentResponse.length !==0) {
                    this.message = "";
                    this.seen = true;
                }

                let tempCalc = 0;
                for (var i = 0; i < this.sentimentResponse.length; i++) {
                    tempCalc += this.sentimentResponse[i].sentiment; 
                }
                
                this.average = tempCalc / this.sentimentResponse.length;

                this.lengthOfResponse = this.sentimentResponse.length;

                console.log("sentimentResponse", this.sentimentResponse);
            }
        }
     })
