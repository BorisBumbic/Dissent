var app = new Vue({
        el: "#app",
        data: {
           
            map: "",
            sentimentResponse: [],
            userinput: "",
            latLng: [lat = 59.40316, lng = 17.94479]
        },
        async created() {

        },
        mounted() {
            this.initMap();
        },
        methods: {
            initMap: function () {
                map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 8,
                    center: new google.maps.LatLng(this.latLng),
                    mapTypeId: 'hybrid'
                });

                this.marker = new google.maps.Marker({
                   
                    position: {this.latLng},
                    map: map,
                    title: 'Drop me at the desired location!',
                    draggable: true
                });
                google.maps.event.addListener(this.marker, 'dragend', function () {

                    //this.lat = this.marker.location.lat();
                    //this.lng = this.marker.location.lng();
                    document.getElementById("lat").value = this.getPosition().lat();
                    document.getElementById("lng").value = this.getPosition().lng();
                  
                });
               
               
            },
            async showTweetSentiment() {
                let response = await fetch("/Tweet/TwitterResult/?input="+this.userinput,{
                method: "get"
                 });

              this.sentimentResponse = await response.json();
              console.log("sentimentResponse", this.sentimentResponse);
            }
        }
    });



    

