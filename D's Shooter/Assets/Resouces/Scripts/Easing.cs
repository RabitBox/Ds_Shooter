// Easing メモ 
// C#
// 常時更新
// 参考URL : http://www.gizma.com/easing/

public static class Easing{
    // simple linear tweening
	public static float Liner(float endTime, float nowTime, float endPosition, float firstPosition)
    {
        if (nowTime > endTime) nowTime = endTime;
		float t = (float)(nowTime / endTime);
		return (float)((endPosition - firstPosition) * t + firstPosition);
	}

    // quadratic easing in
	public static float QuadIn(float endTime, float nowTime, float endPosition, float firstPosition)
    {
        if (nowTime > endTime) nowTime = endTime;
		float t = (float)(nowTime / endTime);
		return (float)((endPosition - firstPosition) * t * t + firstPosition);
	}

    // quadratic easing out
	public static float QuadOut(float endTime, float nowTime, float endPosition, float firstPosition)
    {
        if (nowTime > endTime) nowTime = endTime;
		float t = (float)(nowTime / endTime);
		return (float)(-(endPosition - firstPosition) * t * (t - 2) + firstPosition);
	}

    // quadratic easing in/out
	public static float QuadInOut(float endTime, float nowTime, float endPosition, float firstPosition)
    {
        if (nowTime > endTime) nowTime = endTime;
		float t = (float)(nowTime / (endTime / 2));
		if(t < 1) return (float)(((endPosition - firstPosition)/2) * t * t + firstPosition);
		t--;
		return (float)((-(endPosition - firstPosition)/2) * ((t * (t - 2)) - 1) + firstPosition);
	}

    // cubic easing in
    // cubic easing out
    // cubic easing in/out
    // quartic easing in
    // quartic easing out
    // quartic easing in/out
    // quintic easing in
    // quintic easing out
    // quintic easing in/out
    // sinusoidal easing in
    // sinusoidal easing out
    // sinusoidal easing in/out
    // exponential easing in
    // exponential easing out
    // exponential easing in/out
    // circular easing in
    // circular easing out
    // circular easing in/out
}