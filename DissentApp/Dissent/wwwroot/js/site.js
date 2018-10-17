
async function getTweet() {

    let input = "trump";

    let response = await fetch("/Tweet/TwitterResult/?input=" + input, { method: "POST" });

    if (response.status === 200) {
        let result = await response.json();
        console.log("result.fullText", result.fullText);
    }
}

setInterval(getTweet, 1000);
