(function () {
    (function poll() {
        setTimeout(function () {
            $(".refresh").click();
            console.log("Clicked!")
            poll();
        }, 2000);
    })();
})()