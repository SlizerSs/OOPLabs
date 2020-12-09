using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13._1
{
    static class BPD_DiskInfo
    {
        public static void GetDriveInfo()
        {
            BPD_Log.WriteLog("GetDriveInfo");
            DriveInfo[] disks = DriveInfo.GetDrives();
            foreach(DriveInfo disk in disks)
            {
                Console.WriteLine($"Имя диска - {disk.Name}, объём диска - {disk.TotalSize}, свободное место на диске - {disk.AvailableFreeSpace}, метка тома - {disk.VolumeLabel}, файловая система - {disk.DriveFormat}");
            }
        }
    }
}
