//------------------------------------------------------------------------------------------------
//
//	SmtpMailClient
//
//	Copyright (C) 2017 Soft-Toolware. All Rights Reserved
//
//	The software is a free software.
//	It is distributed under the Code Project Open License (CPOL 1.02)
//	agreement. The full text of the CPOL is given in:
//	https://www.codeproject.com/info/cpol10.aspx
//	
//	The main points of CPOL 1.02 subject to the terms of the License are:
//
//	Source Code and Executable Files can be used in commercial applications;
//	Source Code and Executable Files can be redistributed; and
//	Source Code can be modified to create derivative works.
//	No claim of suitability, guarantee, or any warranty whatsoever is
//	provided. The software is provided "as-is".
//	
//
//------------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;

namespace MRUList
{
    public class MRUList: ArrayList
    {
        private int    iMaxSize { get; set; }
        private string strFilename { get; set; }
        private IsolatedStorageScope isoScope =  IsolatedStorageScope.User | IsolatedStorageScope.Assembly ;
                                                
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="iLength"></param>
        public MRUList(string strName, int iMaxSize = 10 )
        {
            this.iMaxSize = iMaxSize;
            this.strFilename = strName + ".MRU";                      
        }

        /// <summary>
        /// Make a new entry to MRU.
        /// </summary>
        /// <param name="strText"></param>
        public void Update(string strText)
        {
            this.Remove(strText);

            if ( this.Count > this.iMaxSize )		// More than iMaxSize items in the list
                this.RemoveAt(this.iMaxSize);		// remove last (oldest) item

            this.Insert(0, strText);
        }

        /// <summary>
        /// Load MRU from isolated storage.
        /// </summary>
        public void loadFromStorage()
        {
            try
            {
                IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(isoScope, null, null);
                
                if (isoStore.GetFileNames(this.strFilename).Length > 0)
                {
                    // Read the stream from Isolated Storage.
                    IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this.strFilename, FileMode.Open, isoStore);

                    if (stream != null)
                    {
                        StreamReader reader = new StreamReader(stream);

                        while (!reader.EndOfStream)
                            this.Add(reader.ReadLine());
                      
                        reader.Close();
                    }
                }
                isoStore.Dispose();
                isoStore.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                
            }
        }

        /// <summary>
        /// Save MRU to isolated storage.
        /// </summary>
        public void saveToStorage()
        {
            try
            { 
                // Open the stream from the IsolatedStorage.
                IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(isoScope, null, null);

                IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this.strFilename, FileMode.Create, isoStore);

                if (stream != null)
                {
                    StreamWriter writer = new StreamWriter(stream);

                    foreach (var item in this)
                        writer.WriteLine(item);

                    writer.Close();
                }
                
                isoStore.Dispose();
                isoStore.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
