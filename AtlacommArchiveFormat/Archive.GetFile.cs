﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlacomm.Archive
{
    public partial class Archive
    {
        public byte[] GetFile(string filepath)
        {
            long offset = contentOffset;

            byte[] ret = null;

            foreach (string key in index.Keys)
            {
                if (key == filepath)
                {
                    ret = new byte[index[key]];
                    for (long i = 0; i < ret.Length; i++)
                    {
                        ret[i] = data[offset + i];
                    }

                    break;
                }
                offset += index[key];
            }

            return ret;
        }
    }
}
