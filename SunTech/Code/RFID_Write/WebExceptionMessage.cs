using System;
using System.Net;

namespace RFID_Write
{
	/// <summary>
	/// WebExceptionMessage 的摘要说明。
	/// </summary>
	public class WebExceptionMessage
	{

		public static string GetWebExceptionMessage(WebException ex)
		{
			string message;
			switch (ex.Status)
			{
                case WebExceptionStatus.NameResolutionFailure:
                    message = "无法解析服务器名称\n1.网络连接是否正常\n2.服务地址是否正确";
                    break;
                case WebExceptionStatus.ProtocolError:
                    message = "网络HTTP协议错误:\n服务地址是否正确";
                    break;
                case WebExceptionStatus.ReceiveFailure:
                    message = "没有从服务器接收到完整响应\n1.网络连接是否正常\n2.服务地址是否正确";
                    break;
                case WebExceptionStatus.Timeout:
                    message = "连接超时";
                    break;
                case WebExceptionStatus.RequestCanceled: // 请求被取消，WebRequest.Abort 方法被调用，或者发生了不可分类的错误。这是 Status 的默认值。
                    message = "操作已取消";
                    break;
				case WebExceptionStatus.ConnectFailure:  // 未能在传输级联系到远程服务点。
					message = ex.Message;
					break;
				case WebExceptionStatus.ConnectionClosed:  // 连接被过早关闭。
					message = ex.Message;
					break;
				case WebExceptionStatus.KeepAliveFailure:  // 指定 Keep-alive 标头的请求连接被意外关闭。
					message = ex.Message;
					break;
				case WebExceptionStatus.Pending:  // 内部异步请求挂起。
					message = ex.Message;
					break;
				case WebExceptionStatus.PipelineFailure:  // 该成员支持 .NET Framework 结构，因此不适用于直接从代码中使用。
					message = ex.Message;
					break;
				case WebExceptionStatus.ProxyNameResolutionFailure: // 名称解析服务未能解析代理主机名。
                    message = ex.Message;
					break;
				case WebExceptionStatus.SecureChannelFailure: // 安全通道链接中发生错误。
					message = ex.Message;
					break;
				case WebExceptionStatus.SendFailure: // 未能将完整请求发送到远程服务器。
					message = ex.Message;
					break;
				case WebExceptionStatus.ServerProtocolViolation: // 此服务器响应不是有效的 HTTP 响应。
					message = ex.Message;
					break;
				case WebExceptionStatus.Success: // 未遇到任何错误。
					message = ex.Message;
					break;
				case WebExceptionStatus.TrustFailure: // 未能验证服务器证书。
					message = ex.Message;
					break;
				default:
					message = "未知的 WebException 异常！";
					break;

			}

			return message;
		}
	}
}
