/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/28/2022
 * Time: 1:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Alumni
{
	/// <summary>
	/// CSV file.
	/// </summary>
	public class CSVFile
	{
		public string name = null;
		public ArrayList names = new ArrayList();
		public Dictionary<string, int> namesIndex = new Dictionary<string, int>();
		public List<CSVLine> lines = new List<CSVLine>();
		
		public CSVFile(ParsingStream stream, string name)
		{
			this.name = name;
			
			CSVLine namesLine = new CSVLine(stream);
			
			int i = 0;
			
			foreach (string s in namesLine.values) {
				this.names.Add(s);
				
				this.namesIndex.Add(s, i++);
			}
			
			while (!stream.atEnd()) {
				CSVLine line = new CSVLine(stream);
				
				if (line.values.Count > 0) {
					this.lines.Add(line);
				}
			}
			
			stream.stream.Close();
		}
	}
}
