﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AutoNetWatcher
{
    class NetHelper
    {
        /// <summary>
        /// 网卡列表
        /// </summary>
        public string[] NetWorkList()
        {
            string manage = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collection = searcher.Get();
            List<string> netWorkList = new List<string>();

            foreach (ManagementObject obj in collection)
            {
                netWorkList.Add(obj["Name"].ToString());
            }
            return netWorkList.ToArray();
        }

        /// <summary>
        /// 禁用网卡
        /// </summary>5
        /// <param name="netWorkName">网卡名</param>
        /// <returns></returns>
        public bool DisableNetWork(ManagementObject network)
        {
            try
            {
                network.InvokeMethod("Disable", null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 启用网卡
        /// </summary>
        /// <param name="netWorkName">网卡名</param>
        /// <returns></returns>
        public bool EnableNetWork(ManagementObject network)
        {
            try
            {
                network.InvokeMethod("Enable", null);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 网卡状态
        /// </summary>
        /// <param name="netWorkName">网卡名</param>
        /// <returns></returns>
        public bool NetWorkState(string netWorkName)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject manage in collection)
            {
                if (manage["Name"].ToString() == netWorkName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 得到指定网卡
        /// </summary>
        /// <param name="networkname">网卡名字</param>
        /// <returns></returns>
        public ManagementObject NetWork(string networkname)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject manage in collection)
            {
                if (manage["Name"].ToString() == networkname)
                {
                    return manage;
                }
            }

            return null;
        }
    }
}
