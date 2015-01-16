(function () {
    (function changeSortingParams() {
        $(".btn-sort").on("click", function () {
            var filterBtn = $(this);
            var refreshBtn = filterBtn.siblings(".refresh").first();
            var refreshLink = refreshBtn.attr("href");
            var filerValue;

            filterBtn.siblings(".btn-sort").removeClass("btn-primary").addClass("btn-default");
            filterBtn.addClass("btn-primary");

            if (filterBtn.attr("value") === "Ascending") {
                filterBtn.attr("value", "Descending");
                filerValue = "Descending";
            } else {
                filterBtn.attr("value", "Ascending");
                filerValue = "Ascending";
            }

            refreshLink = refreshLink.split("&")[0];
            refreshLink += "&" + filterBtn.attr("name") + "=" + filerValue;
            refreshBtn.attr("href", refreshLink);
        })
    })();

    (function poll() {
        setTimeout(function () {
            $(".refresh").click();
            console.log("Clicked!")
            poll();
        }, 1000);
    })();
})()
