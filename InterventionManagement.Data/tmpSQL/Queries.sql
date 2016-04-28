
-- Total Cost Of Pending Interventions Per Employee(Engineer)
SELECT		i.ProposerId, SUM(i.Cost)
FROM		Intervention i
LEFT JOIN	InterventionState istate
ON			i.InterventionStateId = istate.InterventionStateId
WHERE		InterventionStateName = 'Proposed'
GROUP BY	i.ProposerId;

-- All Interventions for a Single Client (Id 21)
SELECT * 
FROM Intervention i
INNER JOIN Client c
ON i.ClientId = c.ClientId
LEFT JOIN QualityReport ql
ON i.InterventionId = ql.InterventionId
WHERE c.ClientId = 21;

