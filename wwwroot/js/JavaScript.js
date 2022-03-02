$(document).ready(function () {
    $.get('@Url.Action("GetQualifications","Employee")',
        function (result) {
            // console.log(result);
            $.each(result, function (i, dept) {
                $(".dept").append("<option value=" + dept.id
                    + ">" + dept.name + "</option>")
            })
        });

    $.get('@Url.Action("GetCountry","Employee")',
        function (result) {
            //console.log(result);
            $.each(result, function (i, cs) {
                $(".cs").append("<option value=" + cs.c_Id
                    + ">" + cs.countryName + "</option>")
            })
        });
});