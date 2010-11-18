// 全选GridView中所有CheckBox
function SelectAllCheckboxes(spanChk)
{
    var oItem = spanChk.children;
    var theBox=(spanChk.type=="checkbox")?spanChk:spanChk.children.item[0];
    xState=theBox.checked;
    elm=theBox.form.elements;
    for(i=0;i<elm.length;i++)
    if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
    {
        if(elm[i].checked!=xState)
            elm[i].click();
    }
}// Over

var tmp;
function checkValue(obj)
    {
        if (obj.value!="")
        {
            if (isNaN(obj.value))
            {
                alert("请输入数字");
                obj.value="";
            }
            else
            {
                //..alert("fff");
                CheckValue1(obj);
            }
        }
    }
function CheckValue1(object)
{
    if (object.value<0)
        {
                            alert("请输入大于0");
                object.value="";

        }
}
function IsNumber(object)
    {
        if (isNaN(object.value))
        {
            object.value=tmp;
        }
        else
            tmp=object.value;
    }

function Submit(object)
{
    object.disabled="true";
    object.value="提交中...";
}

//绑定最顶层下拉
function BindTop(obj)
{
	obj.options.add(new Option(defaultText,""));
	for (i in train)
	{
		if (train[i][2]==0)
			obj.options.add(new Option(train[i][1],train[i][0]));
	}
}
//绑定其它下拉
function Bind(obj,selectValue)
{
	obj.options.length=0;
	obj.options.add(new Option(defaultText,""));
	if (selectValue!="")
	{
		for (i in train)
		{
			if (train[i][2]==selectValue)
				obj.options.add(new Option(train[i][1],train[i][0]));
		}
	}
}
//初始化
function init(text)
{
	defaultText=text;
	BindTop(arguments[1]);
	for (var i=2;i<arguments.length ;i++ )
		Bind(arguments[i],"");
}