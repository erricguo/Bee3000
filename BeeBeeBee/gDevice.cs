using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.Drawing;

namespace BeeBeeBee
{
    public class gDevice
    {
        public Device pD3DDevice = null;
        //private gDevice device = new gDevice();
        public IntPtr Hwnd = (IntPtr)0;

        public gDevice()
        {
           
        }
          ~gDevice()
        {
        }
        public void SetHwnd(IntPtr xHwnd)
        {
            Hwnd = xHwnd;
        }
        public Device GetInstance()    // 取得裝置界面
        {
            return pD3DDevice;
        }
        public void InitDevice()// 初始化裝置
        {
            CreateDevice_DX();
        }
        private bool CreateDevice_DX()// 建立DirectX9裝置
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true; //指定以Windows窗体形式显示
                presentParams.SwapEffect = SwapEffect.Copy; //当前屏幕绘制后它将自动从内存中删除
                pD3DDevice = new Device(0, DeviceType.Hardware, Hwnd, CreateFlags.HardwareVertexProcessing, presentParams); //实例化device对象
                
                return true;
            }
            catch (DirectXException e)
            {
                MessageBox.Show(e.ToString(), "Error"); //处理异常
                return false;
            }
        }
        public void BeginScene()
        {
            pD3DDevice.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);  //清除windows界面为深蓝色
            pD3DDevice.BeginScene();
            
        }

        public void EndScene()
        {
            // 結束繪製
            pD3DDevice.EndScene();
            // 將畫面呈像
            pD3DDevice.Present();
        }
         
    }
}
