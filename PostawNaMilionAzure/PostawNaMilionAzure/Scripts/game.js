//Variable
valueSum = $('#game-sum-value');

$(document).ready(function () {
    valueSum.text('1000000');

    changeInpiutText();
    addAllWithSum();
    clearAllValueWithSum();
    timer();
    checkTimer();
});

function addAllWithSum() {
    $(document).delegate('#input_all', 'click', function (e) {

        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        $("#input-" + idAnswer).val(parseInt(valueSum.text()) + parseInt($("#input-" + idAnswer).val()));
        valueSum.text('0');
        return false;
    });
}

function changeInpiutText() {
    $(document).delegate('#input_container input', 'focusout', function (e) {
        e.preventDefault();
        valueToAdd = Math.ceil($(this).val() / 25000) * 25000;
        if (valueToAdd <= valueSum.text()) {
            valueSum.text(parseInt(valueSum.text()) - parseInt(valueToAdd));
            $(this).val(valueToAdd);
            return;
        }


        $(this).val(valueSum.text());
        valueSum.text(0);


    })

    $("#input_container input").bind('keyup mouseup', function () {
        if ($(this).val() > valueSum)
        { }

    });
}

function clearAllValueWithSum() {

    $(document).delegate('#input_clear', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        valueSum.text(parseInt(valueSum.text()) + parseInt(+$("#input-" + idAnswer).val()));
        $("#input-" + idAnswer).val('0');
        return false;
    });
}

function timer() {
    $(function () {
        $('.svg-timer').svgTimer();

    });
}

function checkTimer() {
    window.setInterval(function () {
        var value = $(".svg-hexagonal-counter h2");
        if (value.text() == 60) {
            console.log('poszlo');
        }

    }, 500);
}