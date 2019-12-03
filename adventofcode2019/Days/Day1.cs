﻿using adventofcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Days
{
	public class Day1 : IProblem
	{

		private int[] input = {
			92903,
95910       ,
97793       ,
104540      ,
122569      ,
60424       ,
145155      ,
90081       ,
81893       ,
140366      ,
77358       ,
122977      ,
114868      ,
135274      ,
80770       ,
104328      ,
87475       ,
135948      ,
128585      ,
71353       ,
93571       ,
69870       ,
137262      ,
142606      ,
95397       ,
62517       ,
87269       ,
73336       ,
118502      ,
82894       ,
125097      ,
102311      ,
134164      ,
119828      ,
116181      ,
99303       ,
88937       ,
63418       ,
145060      ,
91014       ,
136031      ,
106000      ,
105084      ,
139280      ,
99775       ,
94626       ,
99081       ,
119824      ,
58232       ,
54759       ,
93633       ,
142621      ,
63718       ,
106439      ,
62425       ,
119965      ,
73033       ,
130019      ,
93223       ,
118848      ,
122769      ,
130704      ,
63418       ,
87205       ,
137230      ,
147960      ,
51051       ,
65279       ,
82183       ,
57705       ,
102519      ,
144031      ,
94413       ,
98485       ,
130646      ,
111400      ,
100503      ,
95963       ,
143785      ,
97857       ,
146611      ,
67684       ,
79662       ,
147350      ,
60427       ,
118683      ,
128729      ,
65014       ,
55844       ,
120846      ,
117969      ,
134494      ,
127003      ,
139614      ,
95021       ,
124970      ,
100680      ,
91622       ,
106898      ,
79702
		};

		private int calcFuel(int mass)
		{
			var n = Math.Floor(mass / 3f);

			n -= 2;

			return (int)n;
		}

		public long Answer(params long[] arguments)
		{
			long awnser = 0;

			foreach(int mass in input)
			{
				awnser += calcFuel(mass);
			}

			return awnser;
		}
	}
}
