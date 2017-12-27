//Variable

function showFancyBox() {

    $("#fancybox").fancybox({
        closeBtn: false, // hide close button
        closeClick: false, // prevents closing when clicking INSIDE fancybox

        helpers: {
            // prevents closing when clicking OUTSIDE fancybox
            overlay: { closeClick: false }
        },
        keys: {
            // prevents closing when press ESC button
            close: null
        }
    }).trigger('click');

};

function checkTimer() {
    window.setInterval(function () {
        var value = $(".svg-hexagonal-counter h2");
        if (value.text() == 59) {
            sendAnswer();
        }

    }, 500);
};

function addAllWithSum() {
    $(document).delegate('#input_all', 'click', function (e) {

        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        $("#input-" + idAnswer).val(parseInt($('#game-sum-value').text()) + parseInt($("#input-" + idAnswer).val()));
        $('#game-sum-value').text('0');
        return false;
    });
}

function changeInpiutText() {
    $(document).delegate('#input_container input', 'focusout', function (e) {
        e.preventDefault();
        valueToAdd = Math.ceil($(this).val() / stepValue) * stepValue;
        if (valueToAdd <= $('#game-sum-value').text()) {
            $('#game-sum-value').text(parseInt($('#game-sum-value').text()) - parseInt(valueToAdd));
            $(this).val(valueToAdd);
            return;
        }


        $(this).val($('#game-sum-value').text());
        $('#game-sum-value').text(0);


    })

    $("#input_container input").bind('keyup mouseup', function () {
        if ($(this).val() > $('#game-sum-value'))
        { }

    });
}

function clearAllValueWithSum() {

    $(document).delegate('#input_clear', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) + parseInt(+$("#input-" + idAnswer).val()));
        $("#input-" + idAnswer).val('0');
        return false;
    });
}

function plusValueWithSum() {

    $(document).delegate('#input_plus', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        if (parseInt($('#game-sum-value').text()) <= 0) {
            return;
        }
        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) - stepValue);
        $("#input-" + idAnswer).val(stepValue + parseInt(+$("#input-" + idAnswer).val()));
        return false;
    });
}

function minusValueWithSum() {

    $(document).delegate('#input_minus', 'click', function (e) {
        idAnswer = $(this).attr('data-id');
        e.preventDefault();
        if (parseInt($('#game-sum-value').text()) >= 1000000 || $("#input-" + idAnswer).val() <= 0)
        {
            return;
        }
   

        $('#game-sum-value').text(parseInt($('#game-sum-value').text()) + stepValue);
        $("#input-" + idAnswer).val(parseInt(+$("#input-" + idAnswer).val()) - stepValue);
        return false;
    });
}

function timer() {
    $(function () {
        $('.svg-timer').svgTimer();

    });
}



//Fancy Box
