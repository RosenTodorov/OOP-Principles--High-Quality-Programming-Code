function checkIfBrowserIsMozilla(expectedEvent, arguments) {

    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;
    //var isMozilla = currentBrowser == "Mozilla";

    if (currentBrowser === "Mozilla") {
        alert("The browser name is Mozilla");
    }
    else {
        alert("The browser name is not Mozilla");
    }
}
