var Console = function(){
	var plugin_name = "ConsoleLog";
	var plugin_dir="/plugins/CosoleLog";
	
	//定位插件根目录路径
	function locatePluginDir(){
		var app_path=window.external.GetAppPath();

	}
	return {
		debug:function(pinfo){
			var inData = {
				method :'debug',
				data : pinfo
			}
			return invokePlugin(plugin_name,inData);
		},
		log:function(pinfo){
			var inData = {
				method :'log',
				data : pinfo
			}
			return invokePlugin(plugin_name,inData);
		},
		error:function(pinfo){
			var inData = {
				method :'error',
				data : pinfo
			}
			return invokePlugin(plugin_name,inData);
		}
	}
}();

function invokePlugin(plugin_name,inData){
	return window.external.InvokePlugin(plugin_name,JSON.stringify(inData));
}