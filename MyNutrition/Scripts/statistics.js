$(document).ready(function () {
    LoadStatistics();
});

function LoadStatistics(currentDaysback) {

    if (!currentDaysback) {
        currentDaysback = 5;
    }

    if (currentDaysback <= 1) {
        currentDaysback = 3;
    }

    $.ajax({
        url: "/Account/GetStatistics",
        data: { daysBack: currentDaysback },
        success: function (result) {

            if (!result) {
                $("#caloriesChart").text("No Calories info available.");
                $("#proteinsChart").text("No Proteins info available.");
                $("#vitaminsChart").text("No Vitamins info available.");
                return;
            }

            var dates = [];
            var calories = [];
            var proteins = [];
            var vitamins = {};
            
            dates.push("x");
            calories.push("Calories");
            proteins.push("Proteins");
            vitamins = vitaminsInit();

            for (var day of result) {
                var dateParts = day.Date.split('/');
                var parsedDate = new Date(dateParts[2], dateParts[0] - 1, dateParts[1]);
                dates.push(parsedDate);
                calories.push(day.Calories);
                proteins.push(day.Proteins);
                vitamins.A.push(day.Vitamins.A);
                vitamins.C.push(day.Vitamins.C);
                vitamins.D.push(day.Vitamins.D);
                vitamins.E.push(day.Vitamins.E);
                vitamins.K.push(day.Vitamins.K);
                vitamins.Thiamin.push(day.Vitamins.Thiamin);
                vitamins.Riboflavin.push(day.Vitamins.Riboflavin);
                vitamins.Niacin.push(day.Vitamins.Niacin);
                vitamins.B6.push(day.Vitamins.B6);
                vitamins.Folate.push(day.Vitamins.Folate);
                vitamins.B12.push(day.Vitamins.B12);
                vitamins.PantothenicAcid.push(day.Vitamins.PantothenicAcid);
                vitamins.Choline.push(day.Vitamins.Choline);
                vitamins.Betaine.push(day.Vitamins.Betaine);
            }

            var caloriesChart = c3.generate({
                bindto: '#caloriesChart',
                size: {
                    height: 350,
                    width: 600
                },
                data: {
                    x: 'x',
                    columns: [
                      dates,
                      calories
                    ],
                    //type: 'spline'
                },
                axis: {
                    x: {
                        type: 'timeseries',
                        tick: {
                            format: '%m-%d-%Y'
                        }
                    }
                }
            });

            var proteinsChart = c3.generate({
                bindto: '#proteinsChart',
                size: {
                    height: 350,
                    width: 600
                },
                data: {
                    x: 'x',
                    columns: [
                      dates,
                      proteins
                    ],
                    //type: 'spline'
                },
                axis: {
                    x: {
                        type: 'timeseries',
                        tick: {
                            format: '%m-%d-%Y'
                        }
                    }
                },
            });

            var vitaminsChart = c3.generate({
                bindto: '#vitaminsChart',
                size: {
                    height: 350,
                    width: 600
                },
                data: {
                    x: 'x',
                    columns: [
                      dates,
                      vitamins.A,
                      vitamins.C,
                      vitamins.D,
                      vitamins.E,
                      vitamins.K,
                      vitamins.Thiamin,
                      vitamins.Riboflavin,
                      vitamins.Niacin,
                      vitamins.B6,
                      vitamins.Folate,
                      vitamins.B12,
                      vitamins.PantothenicAcid,
                      vitamins.Choline,
                      vitamins.Betaine
                    ],
                    //type: 'spline'
                },
                axis: {
                    x: {
                        type: 'timeseries',
                        tick: {
                            format: '%m-%d-%Y'
                        }
                    }
                }
            });

        },
        error: function (error) {
            alert('error; ' + JSON.stringify(error));
        }
    });
}

function vitaminsInit() {
    storage = {}

    storage.A = [];
    storage.C = [];
    storage.D = [];
    storage.E = [];
    storage.K = [];
    storage.Thiamin = [];
    storage.Riboflavin = [];
    storage.Niacin = [];
    storage.B6 = [];
    storage.Folate = [];
    storage.B12 = [];
    storage.PantothenicAcid = [];
    storage.Choline = [];
    storage.Betaine = [];

    storage.A.push("A");
    storage.C.push("C");
    storage.D.push("D");
    storage.E.push("E");
    storage.K.push("K");
    storage.Thiamin.push("Thiamin");
    storage.Riboflavin.push("Riboflavin");
    storage.Niacin.push("Niacin");
    storage.B6.push("B6");
    storage.Folate.push("Folate");
    storage.B12.push("B12");
    storage.PantothenicAcid.push("PantothenicAcid");
    storage.Choline.push("Choline");
    storage.Betaine.push("Betaine");

    return storage;
}