/*********
 *		Author: James Keeling
 *		Purpose: Basic interface for drug pickup effects.
 ********/

using UnityEngine;
using System.Collections;

public interface IDrugAffectable{
	/// <summary>
	/// Start the effect of drug
	/// </summary>
	/// <param name="p"></param>
	void DrugEffectStart( Player p );

	/// <summary>
	/// Remove the effects of the drug
	/// </summary>
	/// <param name="p"></param>
	void DrugEffectOver( Player p );

	/// <summary>
	/// CoRoutine that lasts until the drug effect's exit condition is reached
	/// </summary>
	/// <param name="p"></param>
	/// <returns></returns>
	IEnumerator DrugActive( Player p );
}
