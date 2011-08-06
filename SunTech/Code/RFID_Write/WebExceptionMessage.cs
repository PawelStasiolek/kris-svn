using System;
using System.Net;

namespace RFID_Write
{
	/// <summary>
	/// WebExceptionMessage ��ժҪ˵����
	/// </summary>
	public class WebExceptionMessage
	{

		public static string GetWebExceptionMessage(WebException ex)
		{
			string message;
			switch (ex.Status)
			{
                case WebExceptionStatus.NameResolutionFailure:
                    message = "�޷���������������\n1.���������Ƿ�����\n2.�����ַ�Ƿ���ȷ";
                    break;
                case WebExceptionStatus.ProtocolError:
                    message = "����HTTPЭ�����:\n�����ַ�Ƿ���ȷ";
                    break;
                case WebExceptionStatus.ReceiveFailure:
                    message = "û�дӷ��������յ�������Ӧ\n1.���������Ƿ�����\n2.�����ַ�Ƿ���ȷ";
                    break;
                case WebExceptionStatus.Timeout:
                    message = "���ӳ�ʱ";
                    break;
                case WebExceptionStatus.RequestCanceled: // ����ȡ����WebRequest.Abort ���������ã����߷����˲��ɷ���Ĵ������� Status ��Ĭ��ֵ��
                    message = "������ȡ��";
                    break;
				case WebExceptionStatus.ConnectFailure:  // δ���ڴ��伶��ϵ��Զ�̷���㡣
					message = ex.Message;
					break;
				case WebExceptionStatus.ConnectionClosed:  // ���ӱ�����رա�
					message = ex.Message;
					break;
				case WebExceptionStatus.KeepAliveFailure:  // ָ�� Keep-alive ��ͷ���������ӱ�����رա�
					message = ex.Message;
					break;
				case WebExceptionStatus.Pending:  // �ڲ��첽�������
					message = ex.Message;
					break;
				case WebExceptionStatus.PipelineFailure:  // �ó�Ա֧�� .NET Framework �ṹ����˲�������ֱ�ӴӴ�����ʹ�á�
					message = ex.Message;
					break;
				case WebExceptionStatus.ProxyNameResolutionFailure: // ���ƽ�������δ�ܽ���������������
                    message = ex.Message;
					break;
				case WebExceptionStatus.SecureChannelFailure: // ��ȫͨ�������з�������
					message = ex.Message;
					break;
				case WebExceptionStatus.SendFailure: // δ�ܽ����������͵�Զ�̷�������
					message = ex.Message;
					break;
				case WebExceptionStatus.ServerProtocolViolation: // �˷�������Ӧ������Ч�� HTTP ��Ӧ��
					message = ex.Message;
					break;
				case WebExceptionStatus.Success: // δ�����κδ���
					message = ex.Message;
					break;
				case WebExceptionStatus.TrustFailure: // δ����֤������֤�顣
					message = ex.Message;
					break;
				default:
					message = "δ֪�� WebException �쳣��";
					break;

			}

			return message;
		}
	}
}
