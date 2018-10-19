
new Vue({
    el: "#app",
    data: {
        sentimentResponse: [],
        userinput: "Kalle"
    },
    async created() {
        console.log("hej");
        //await this.showTweetSentiment();
    },
    methods: {

        async showTweetSentiment() {
            let response = await fetch("/Tweet/TwitterResult/?input="+this.userinput, {
                method: "get"
            });

            this.sentimentResponse = await response.json();
            console.log("sentimentResponse", this.sentimentResponse);
        }
    }
});

