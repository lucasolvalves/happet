$(document).ready(function () {

    typeFormByTypePerson();
});


function typeFormByTypePerson() {
    $(':radio[name="type"]').change(function () {
        var typePerson = $(this).filter(':checked').val();

        if (typePerson === "adopter") {
            $("#ong").css("display", "none");
            $("#adopter").css("display", "block");

        } else {
            $("#adopter").css("display", "none");
            $("#ong").css("display", "block");
        }

        alert(category);
    });
}