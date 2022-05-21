
var cards = [];

var sizeLabels = [
    // Size
    { name: "BloomingSized", id: "5e56d746c5de3141740878a0", html: "<span class=\"tag size\">BS</span>", descr: "Blooming Size" },
    { name: "NearBloomingSized", id: "5e56d746c5de3141740878aa", html: "<span class=\"tag size\">NBS</span>", descr: "Near Blooming Size" },
    { name: "Seedling", id: "5e56d746c5de3141740878a8", html: "<span class=\"tag size\">Seedling</span>", descr: "Seedling" }];

var bloomingLabels = [
    // Blooming
    { name: "InBudOrBloom", id: "5e56d746c5de3141740878a2", html: "<span class=\"bud\"><img src=\"orchid.png\" /></span>", descr: "In bud or bloom" },
    { name: "NotInBud", id: "5d9cdce0b630816a6b17a116", html: "", descr: "" }];

var temperatureLabels = [
    // Temperature
    { name: "TempC", id: "5e56d746c5de31417408788a", html: "<span class=\"temperature\"><img src=\"cool.png\" /></span>", descr: "Cool" },
    { name: "TempCI", id: "5e56d746c5de3141740878c0", html: "<span class=\"temperature\"><img src=\"cool.png\" /><img src=\"warm.png\" /></span>", descr: "Cool-Intermediate" },
    { name: "TempCW", id: "5e56d746c5de3141740878c2", html: "<span class=\"temperature\"><img src=\"cool.png\" /><img src=\"hot.png\" /></span>", descr: "Cool-Warm" },
    { name: "TempI", id: "5e56d746c5de31417408788c", html: "<span class=\"temperature\"><img src=\"warm.png\" /></span>", descr: "Intermediate" },
    { name: "TempIW", id: "5e56d746c5de3141740878b8", html: "<span class=\"temperature\"><img src=\"warm.png\" /><img src=\"hot.png\" /></span>", descr: "Intermediate-Warm" },
    { name: "TempW", id: "5e56d746c5de31417408788e", html: "<span class=\"temperature\"><img src=\"hot.png\" /></span>", descr: "Warm" },
    { name: "TempWC", id: "5e56d746c5de3141740878ba", html: "<span class=\"temperature\"><img src=\"hot.png\" /><img src=\"cool.png\" /></span>", descr: "Warm-Cool" },
    { name: "TempWI", id: "5e56d746c5de3141740878be", html: "<span class=\"temperature\"><img src=\"hot.png\" /><img src=\"warm.png\" /></span>", descr: "Warm-Intermediate" }];

var wateringLabels = [
    // Watering
    { name: "WaterM", id: "5e56d746c5de314174087886", html: "<span class=\"tag water\">M</span>", descr: "Keep evenly moist" },
    { name: "WaterMW", id: "5e56d746c5de31417408787c", html: "<span class=\"tag water\">M/DW</span>", descr: "Do not allow to dry" },
    { name: "WaterMD", id: "5e56d746c5de3141740878b6", html: "<span class=\"tag water\">M/D</span>", descr: "Keep Moist, prefers dryer" },
    { name: "WaterD", id: "5e56d746c5de314174087888", html: "<span class=\"tag water\">D</span>", descr: "Allow drying between watering" },
    { name: "WaterDM", id: "5e56d746c5de3141740878bc", html: "<span class=\"tag water\">D/M</span>", descr: "Allow to nearly dry between watering" }];

var lightingLabels = [
    // Lighting
    { name: "LightDS", id: "5e56d746c5de3141740878b2", html: "<span class=\"light\"><img src=\"deepshade.png\" /></span>", descr: "Heavy shading" },
    { name: "LightL", id: "5e56d746c5de314174087894", html: "<span class=\"light\"><img src=\"intermediate-shade.png\" /></span>", descr: "Shaded" },
    { name: "LightI", id: "5e56d746c5de314174087892", html: "<span class=\"light\"><img src=\"intermediate.png\" /></span>", descr: "Intermediate" },
    { name: "LightH", id: "5e56d746c5de3141740878b4", html: "<span class=\"light\"><img src=\"intermediate-full.png\" /></span>", descr: "Filtered Sun" },
    { name: "LightFS", id: "5e56d746c5de314174087890", html: "<span class=\"light\"><img src=\"fullsun.png\" /></span>", descr: "Full or Near Full Sun" }];

var formatLabels = [
    // Format
    { name: "2-inch", id: "5e56d746c5de31417408789c", html: "<span class=\"tag format\">2\"</span>", descr: "" },
    { name: "2.5-inch", id: "5e56d746c5de314174087898", html: "<span class=\"tag format\">2.5\"</span>", descr: "" },
    { name: "3-inch", id: "5e56d746c5de3141740878a6", html: "<span class=\"tag format\">3\"</span>", descr: "" },
    { name: "3.5-inch", id: "5e56d746c5de31417408789a", html: "<span class=\"tag format\">3.5\"</span>", descr: "" },
    { name: "4-inch", id: "5e56d746c5de3141740878a4", html: "<span class=\"tag format\">4\"</span>", descr: "" },
    { name: "5-inch", id: "5e56d746c5de3141740878ac", html: "<span class=\"tag format\">5\"</span>", descr: "" },
    { name: "6-inch", id: "5e56d746c5de31417408789e", html: "<span class=\"tag format\">6\"</span>", descr: "" },
    { name: "8-inch", id: "5e56d746c5de3141740878ae", html: "<span class=\"tag format\">8\"</span>", descr: "" },
    { name: "Mounted", id: "5e56d746c5de314174087896", html: "<span class=\"tag format\">Mounted</span>", descr: "Wood, Tree fern, or Kool-Log Mounted" }];

var otherLabels = [
    // Other
    { name: "Fragrant", id: "5e56d746c5de3141740878b0", html: "<span class=\"misc\"><img src=\"scent.jpg\" /></span>", descr: "Fragrance" },
    { name: "WinterRest", id: "5e56d746c5de314174087884", html: "<span class=\"misc\"><img src=\"winter.png\" /></span>", descr: "Requires a winter rest" }];

var labelGroups = [
    bloomingLabels, temperatureLabels, lightingLabels, wateringLabels,
    sizeLabels, formatLabels];

$.getJSON("https://trello.com/b/w8Okf2tn.json", function (data) {
    $.each(data.cards, function (key, val) {
        if ((val.idList != "5e56d746c5de314174087752") && !val.closed) {
            cards.push(val);
        }
    });

    cards.sort(function (a, b) {
        var aName = a.name.toLowerCase();
        var bName = b.name.toLowerCase();
        return ((aName < bName) ? -1 : ((aName > bName) ? 1 : 0));
    });

    var items = [];
    $.each(cards, function (key, val) {
        if (val.idList != "5e56d746c5de314174087752") {
            items.push("<tr><td colspan=\"2\">");
            items.push("<h3>" + val.name + "</h3>");
            items.push("</td></tr><tr><td class=\"photo\" rowspan=\"3\">");
            if (val.attachments.length)
                items.push("<img class=\"photo\" src=\"" + val.attachments[0].url + "\" />");
            items.push("</td><td class=\"attrib\">");

            $.each(labelGroups, function (ndx, group) {
                $.each(group, function (ndx, label) {
                    if (val.idLabels.indexOf(label.id) >= 0)
                        items.push(label.html);
                });
            });

            items.push("</td></tr>");
            items.push("<tr><td class=\"desc\">");
            items.push("<div class=\"desc\">" + val.desc + "</div>");
            items.push("</td></tr><tr><td class=\"country\"></td></tr>");
            //$.each( val, function( key, val ) {
            //  items.push( "<li id='" + key + "'>" + key + " ==> " + val + "</li>" );
            //});
            $("<table/>", {
                "class": "plant-table",
                html: items.join("")
            }).appendTo("#plants");
            items = [];
        }
    });

    // Temperature
    items = [];
    items.push("<tr><td>");
    items.push(temperatureLabels[0].html);
    items.push("</td><td>");
    items.push(temperatureLabels[0].descr);
    items.push("</td></tr>");
    items.push("<tr><td>");
    items.push(temperatureLabels[3].html);
    items.push("</td><td>");
    items.push(temperatureLabels[3].descr);
    items.push("</td></tr>");
    items.push("<tr><td>");
    items.push(temperatureLabels[5].html);
    items.push("</td><td>");
    items.push(temperatureLabels[5].descr);
    items.push("</td></tr>");

    $("<table/>", {
        //"class": "my-new-list",
        html: items.join("")
    }).appendTo("#temperature");

    // Light
    items = [];

    $.each(lightingLabels, function (key, val) {
        items.push("<tr><td>");
        items.push(val.html);
        items.push("</td><td>");
        items.push(val.descr);
        items.push("</td></tr>");
    });

    $("<table/>", {
        //"class": "my-new-list",
        html: items.join("")
    }).appendTo("#light");

    // Water
    items = [];

    $.each(wateringLabels, function (key, val) {
        items.push("<tr><td>");
        items.push(val.html);
        items.push("</td><td>");
        items.push(val.descr);
        items.push("</td></tr>");
    });

    $("<table/>", {
        //"class": "my-new-list",
        html: items.join("")
    }).appendTo("#water");

    // Other
    var other = [];
    other.push(bloomingLabels[0]);
    $.each(otherLabels, function (key, val) { other.push(val); });
    $.each(sizeLabels, function (key, val) { other.push(val); });
    other.push({ name: "pot size", html: formatLabels[0].html + "&nbsp;-" + formatLabels[7].html, descr: "Pot/Basket size" });
    other.push(formatLabels[8]);

    items = [];

    $.each(other, function (key, val) {
        items.push("<tr><td>");
        items.push(val.html);
        items.push("</td><td>");
        items.push(val.descr);
        items.push("</td></tr>");
    });

    $("<table/>", {
        //"class": "my-new-list",
        html: items.join("")
    }).appendTo("#other");

});
