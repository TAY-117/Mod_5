using System;

namespace Mod_5.HomeWork
{
	class Program
	{
		static int GetIntControl (string qwest)
		// метод возвращает целое число, введённое пользователем в консоли с клавиатуры
		// запрос повторяется пока пользователь не введёт число > 0 (корректное)
		// qwest - вопрос, задаваемый пользователю
		{
			bool is_good = false;	// признак корректного ответа
			int get_int = 0;			// возвращаемое целое число, начальное значение (некорректное)
			do
			{
				Console.Write($"{qwest}");								// задаём вопрос
				string str_enter = Console.ReadLine();				// считываем ответ
				if (int.TryParse(str_enter, out int int_enter))	// пытаемся конвертировать строку в целое число
				{
					if (int_enter > 0)									// если число корректное
					{
						get_int = int_enter;								// то присваем его значение возвращаемому числу
						is_good = true;									// это корректный ответ - можно будет выйти из цикла
					}
					else { Console.WriteLine("Число должно быть > 0.");}
				}
				else {Console.WriteLine("Введённая строка не является числом.");}
			} while (!is_good);		// если не корректный ответ, то повторяем цикл запроса
			return get_int;			// возвращаем целое число
		}

		static bool GetBoolControl (string qwest)
		// метод возвращает true или false, как результат ответа пользователя в консоли с клавиатуры
		// запрос повторяется пока пользователь не ответит "да" || "yes" || "нет" || "no"(корректные ответы)
		// qwest - вопрос, задаваемый пользователю
		{
			bool is_good;					// признак корректного ответа
			string str_ans;				// строка ответа
			bool bool_ans = false;		// логическая переменная, как результат ответа пользователя
			do
			{
				Console.Write($"{qwest} (да / нет) (yes / no): ");			// задаём вопрос
				str_ans = Console.ReadLine();										// считываем ответ
				str_ans = str_ans.ToLower();										// конвертируем строку в нижний регистр
				is_good = (str_ans == "да") || (str_ans == "нет") || (str_ans == "yes") || (str_ans == "no"); // проверка на корректность
				if (is_good)															// если ответ корректный
				{ bool_ans = (str_ans == "да") || (str_ans == "yes"); }	// то определяем true или false
				else { Console.WriteLine("Ответ не корректный."); }
			} while (!is_good);			// если не корректный ответ, то повторяем цикл запроса
			return bool_ans;           // возвращаем true или false
		}

		static string[] GetArrayElem(int i_num, string word_1, string word_2)
		// метод возвращает массив строк наименований, которые вводит пользователь в консоли с клавиатуры
		// i_num - размер (количество элементов) массива строк
		// word_1 - первое слово в запросе, типа "Имя" или "Наименование" элемента
		// word_2 - второе слово в запросе, типа "питомца" или "цвета", описывающее какого элемента название в массиве
		{
			var str_names = new string[i_num];  // задаём размер массива строк
			if (i_num == 1)							// если элемент всего один, то запрос без уточнения "1-го"
			{
				Console.Write($"{word_1} {word_2}: "); str_names[0] = Console.ReadLine(); // запрос строки массива и запись её в массив, без контроля содержания
			}
			else
			{
				for (int i = 0; i < i_num; i++)  // в цикле запрашиваем строки массива и записываем их в массив, без контроля содержания
				{
					Console.Write($"{word_1} {i + 1}-го {word_2}: "); str_names[i] = Console.ReadLine();
				}
			}
			return str_names;                   // возвращаем заполненный массив строк заданного размера
		}

		static (string name, string fam_name, int age, bool has_pets, string[] pet_names, string[] fv_colors) GetDataUser()
		// метод возвращает основные данные пользователя
		{
			(
				string name,        // имя
				string fam_name,    // фамилия
				int age,            // возраст
				bool has_pets,      // есть ли у пользователя питомцы
				string[] pet_names, // массив имён питомцев
				string[] fv_colors  // массив любимых цветов (краски)
			) data;                // кортеж данных пользователя

			int i_pets;            // число питомцев пользователя, если нет, то 0
			int i_colors;          // число любимых цветов (краски) пользователя, всегда > 0

			Console.Write("Фамилия пользователя: "); data.fam_name = Console.ReadLine();
			Console.Write("Имя пользователя    : "); data.name = Console.ReadLine();
			data.age = GetIntControl("Возраст пользователя, лет: ");
			data.has_pets = GetBoolControl("Есть у пользователя хоть один питомец?");
			if (data.has_pets)
			{
				i_pets = GetIntControl("Число питомцев у пользователя: ");
				data.pet_names = GetArrayElem(i_pets, "Имя", "питомца");
			}
			else
			{
				i_pets = 0;
				data.pet_names = new string[i_pets];
			}
			i_colors = GetIntControl("Число любимых цветов (краски) пользователя: ");
			data.fv_colors = GetArrayElem(i_colors, "Название", "цвета");
			return data;         // возвращаем основные данные о пользователе
		}

		static void ShowDataUser(string name, string fam_name, int age, bool has_pets, string[] pet_names, string[] fv_colors)
		{
			Console.WriteLine("\nДАННЫЕ О ПОЛЬЗОВАТЕЛЕ");
			Console.WriteLine($"Фамилия: {fam_name}");
			Console.WriteLine($"Имя    : {name}");
			Console.WriteLine($"Возраст, лет: {age}");
			Console.Write("Наличие питомцев: ");
			if (has_pets)
			{
				Console.WriteLine("есть.");
				Console.WriteLine("Имена питомцев:");
				for (int i = 0; i < pet_names.Length; i++)
				{
					Console.WriteLine(pet_names[i]);
				}
			}
			else
			{
				Console.WriteLine("нет.");
			};
			Console.WriteLine("Наименования любимых цветов (краски):");
			for (int i = 0; i < fv_colors.Length; i++)
			{
				Console.WriteLine(fv_colors[i]);
			}
			Console.WriteLine("\nЭто всё. Нажмите любую клавишу.");
			Console.ReadKey();
		}

		static void Main(string[] args)
		{
			(string name,        // имя
			 string fam_name,    // фамилия 
			 int age,            // возраст
			 bool has_pets,      // есть ли у пользователя питомцы
			 string[] pet_names, // массив имён питомцев
			 string[] fv_colors  // массив любимых цветов (краски)
			) user;              // кортеж данных пользователя

			user = GetDataUser();
			ShowDataUser(user.name, user.fam_name, user.age, user.has_pets, user.pet_names, user.fv_colors);
		}
	}
}
