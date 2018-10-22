

 


var app;

function initMap() {
    app = new Vue({
        el: "#app",
        data: {
           
            map: "",
            mapOptions: {},
            marker:"",
            sentimentResponse: [],
            userinput: "",
            lat: "",
            lng: "",
            radius:""
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
                    center: new google.maps.LatLng(59.40316, 17.94479),
                    mapTypeId: 'hybrid'
                });

                this.marker = new google.maps.Marker({
                   
                    position: { lat: 59.40316, lng: 17.94479 },
                    map: map,
                    title: 'Drop me at the desired location!',
                    draggable: true
                });
                google.maps.event.addListener(this.marker, 'dragend', function () {


                    app.lat = this.getPosition().lat();
                    app.lng = this.getPosition().lng();
                    
                  
                });
               
               
            },

          
            async showTweetSentiment() {
                let response = await fetch("/Tweet/TwitterResult/?input=" + this.userinput+"&lat=" + this.lat+ "&lng=" + this.lng+"&radius="+this.radius,{
                method: "get"
                 });

              this.sentimentResponse = await response.json();
              console.log("sentimentResponse", this.sentimentResponse);
            }
        }
    });
}


    


