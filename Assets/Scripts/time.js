var o_countdownTimer : countdownTimer;

var f_timerdone = timerDone;

o_countdownTimer = GetComponent(countdownTimer);

o_countdownTimer.setStartTime(90.0);

o_countdownTimer.setTimerDoneAction(f_timerdone);

o_countdownTimer.setTimerState(true);

 

function timerDone() {

    guiText.text = "done!";

}