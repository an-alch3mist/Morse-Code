using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_MORSE_CODE : MonoBehaviour
{
	public R.resource[] resources;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			StopAllCoroutines();
			StartCoroutine(STIMULATE());
		}
	}



	IEnumerator STIMULATE()
	{
		#region frame_rate

		yield return null;
		#endregion


		R.RESOURCES = this.resources;

		SOS.INTIALIZE();
		Debug.Log(SOS.morse_letters);
		//
		StartCoroutine(SOS.SOS_routine());


		yield return null;
	}





	public static class SOS
	{
		// in milli-second //
		public static int time_dot = 160;
		// public static int time_dash = 600;
		public static int time_letter = 800;

		// in milli-second //

		public static string morse_letters;
		public static string[] morse_codes;


		static int KEY_DOWN_TIME = 0;
		static int KEY_UP_TIME = 0;
		static bool str_log_required = true;


		public static void INTIALIZE()
		{
			morse_letters = "abcdefghijklmnopqrstuvwxyz0123456789";
			//
			morse_codes = new string[]
			{
				".-",      // a
				"-...",    // b
				"-.-.",    // c
				"-..",     // d
				".",       // e
				"..-.",    // f
				"--.",     // g
				"....",    // h
				"..",      // i
				".---",    // j

				"-.-",     // k
				".-..",    // l
				"--",      // m
				"-.",      // n
				"---",     // o
				".--.",    // p
				"--.-",    // q
				".-.",     // r
				"...",     // s
				"-",       // t

				"..-",     // u
				"...-",    // v
				".--",     // w
				"-..-",    // x
				"-.--",    // y
				"--..",    // z

				// 0 - 9 //
				"-----",   // 0
				".----",   // 1
				"..---",   // 2
				"...--",   // 3
				"....-",   // 4
				".....",   // 5
				"-....",   // 6
				"--...",   // 7
				"---..",   // 8
				"----."    // 9
				// 0 - 9 //
			};


			KEY_DOWN_TIME = 0;
			KEY_UP_TIME = 0;
			str_log_required = false;
		}


		public static IEnumerator SOS_routine()
		{
			string str_sos = "";
			AudioSource audio = R.obj("AUDIO").GetComponent<AudioSource>();

			while(true)
			{
				int dt = (int)((1 * Time.deltaTime) * 1000);

				//
				if(Input.GetKey(KeyCode.Space))
				{
					if(KEY_UP_TIME != 0)
					{
						//
						KEY_UP_TIME = 0;
					}


					// play audio at begining of space down //
					if(KEY_DOWN_TIME == 0)
					{
						audio.Play(); 
					}
					// play audio at begining of space down //

					KEY_DOWN_TIME = KEY_DOWN_TIME + dt;
					// Debug.Log(KEY_DOWN_TIME);
					//
					str_log_required = true;


					
				}
				else
				{
					if (KEY_DOWN_TIME != 0)
					{
						char sos = '.';
						if(KEY_DOWN_TIME <= time_dot)
						{
							sos = '.';
						}
						else if (KEY_DOWN_TIME > time_dot)
						{
							sos = '-';
						}

						str_sos += sos.ToString();
						//
						KEY_DOWN_TIME = 0;


						audio.Stop();
					}

					//
					KEY_UP_TIME = KEY_UP_TIME + dt;
					if (KEY_UP_TIME >= time_letter && str_log_required == true)
					{
						Debug.Log(str_sos);

						string matched_morse_letter = "none";
						for(int i1 = 0; i1 < morse_codes.Length; i1 += 1)
						{
							if(C.str_match(str_sos , morse_codes[i1]))
							{
								matched_morse_letter = morse_letters[i1].ToString();
							}
						}

						Debug.Log("matched morse-letter: " + matched_morse_letter);



						str_sos = ""; // clear
						str_log_required = false;
					}


				}
				//
				yield return null;
			}
		}



	}



	public static class C
	{
		public static bool str_match(string a , string b)
		{
			if(a.Length != b.Length) { return false; }

			//
			for(int i0 = 0; i0 < a.Length; i0 += 1)
			{
				if(a[i0] != b[i0]) { return false; }
			}
			//
			return true;
		}


	}



}
