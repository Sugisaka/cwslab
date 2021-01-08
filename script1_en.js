var image = new Array("top_fig_en-01.svg","top_fig_en-02.svg","top_fig_en-03.svg","top_fig_en-04.svg");
var idx = 0;

function draw()
{
	document.getElementById("slideshow").src = image[idx];
	setTimeout("draw()",6000);
	if (idx == 3)
	{
		idx = 0;
	}
	else
	{
		idx ++;
	}
}
