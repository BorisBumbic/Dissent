

 

//async function showTweetSentiment() {
//    let userinput = "";
//    byId("userInput").value= userinput
//    let response = await fetch("/Tweet/TwitterResult/?input=" + userinput, {
//        method: "get"
//    });
//    let html
//    let sentimentResponse = await response.json();
//    for (let result of sentimentResponse) {

//        html +=
//            `<tr>
               
//                <td>${ result.text}</td>
//                <td>${ result.language}</td>
//                <td>${ result.sentiment}</td>
              
//            </tr>`
//    }

//    byId("sentimentResult").innerHTML = html;


//}  

//function byId(id) {
//    return document.getElementById(id);
//}
function initMap() {
    var app = new Vue({
        el: "#app",
        data: {
           
            map: "",
            mapOptions: {},
            marker:"",
            sentimentResponse: [],
            userinput: "",
            lat: "",
            lng: "",
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
}


    

//new Vue({
//    el: "#map",
//    data: {
//        sentimentResponse: [],
//        userinput: "",
     
//    },
    
//    methods: {

//        async showTweetSentiment() {
//            let response = await fetch("/Tweet/TwitterResult/?input="+this.userinput,{
//                method: "get"
//            });

//            this.sentimentResponse = await response.json();
//            console.log("sentimentResponse", this.sentimentResponse);
//        }
//    }
//});

